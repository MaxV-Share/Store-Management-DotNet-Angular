import { yupResolver } from '@hookform/resolvers/yup';
import { AppBar, Box, Button, Container, Dialog, IconButton, makeStyles, Tab, Tabs, Toolbar, Typography, useTheme } from '@material-ui/core';
import CloseIcon from '@material-ui/icons/Close';
import { useAppDispatch, useAppSelector } from 'app/hooks';
import { Transition } from 'components/Common';
import TabPanel from 'components/Common/TabPanel';
import { InputField } from 'components/FormFields';
import { IBaseAddOrUpdateBodyRequest, ICategoryAddOrUpdateModel } from 'models';
import React, { useEffect, useState } from 'react';
import { useForm } from 'react-hook-form';
import SwipeableViews from 'react-swipeable-views';
import * as yup from 'yup';
import { categoryActions, selectCategoryAddOrUpdate, selectLangs } from '../categorySlice';

const useStyles = makeStyles((theme) => ({
  appBar: {
    position: 'relative',
  },
  title: {
    marginLeft: theme.spacing(2),
    flex: 1,
  },
  root: {
    '& .MuiTextField-root': {
      margin: theme.spacing(1),
      width: '25ch',
    },
  },
}));

export interface CategoryFormProps {
  //initialValues: ICategoryAddOrUpdateRequest | undefined;
  openModal: boolean;
  onClose: () => void;
  // categoryId?: number | null;
  // control: Control<ICategoryViewModel, object>;
  // onSubmit?: (formValues: ICategoryViewModel) => void;
}

const schema = yup.object().shape({
  data: yup.object().shape({
    details: yup.array().of(yup.object().shape({
      name: yup
        .string()
        .required('Please enter name.')
    }))
  })
});

export default function CategoryForm({ openModal, onClose: handleCloseForm }: CategoryFormProps) {
  const [error, setError] = useState<string>('');
  const classes = useStyles();
  const theme = useTheme();
  const [tabId, setTabId] = React.useState(0);
  const langs = useAppSelector(selectLangs);
  const dispatch = useAppDispatch();

  const handleClose = () => {
    reset({})
    handleCloseForm();
  };

  const categoryAddOrUpdate = useAppSelector(selectCategoryAddOrUpdate);
  useEffect(() => {
    reset({ data: categoryAddOrUpdate });
  }, [categoryAddOrUpdate, openModal])

  const { control,
    handleSubmit,
    reset,
    formState: { isSubmitting, errors }, } = useForm<IBaseAddOrUpdateBodyRequest<ICategoryAddOrUpdateModel>, object>({
      defaultValues: {
        data: {
          details: [{
            name: '',
          }, {
            name: '',
          }]
        }
      },
      resolver: yupResolver(schema),
    });

  const handleFormSubmit = (formValues: IBaseAddOrUpdateBodyRequest<ICategoryAddOrUpdateModel>) => {
    try {
      dispatch(categoryActions.addOrUpdateCategory(formValues.data));
      handleClose();
      // await onSubmit?.(formValues);
    } catch (error: any) {
      setError(error.message);
    }
  };

  const handleChange = (event: React.ChangeEvent<{}>, newValue: number) => {
    setTabId(newValue);
  };

  const handleChangeIndex = (index: number) => {
    setTabId(index);
  };

  return (
    <>
      <Dialog fullScreen open={openModal} onClose={handleClose} TransitionComponent={Transition}>
        <form onSubmit={handleSubmit(handleFormSubmit)}>
          <AppBar className={classes.appBar}>
            <Toolbar>
              <IconButton edge="start" color="inherit" onClick={handleClose} aria-label="close">
                <CloseIcon />
              </IconButton>
              <Typography variant="h6" className={classes.title}>
                Category Detail {categoryAddOrUpdate.id == null ? 'Add' : 'Edit'}
              </Typography>
              <Button autoFocus color="inherit" type="submit" >
                save
              </Button>
            </Toolbar>
          </AppBar>
          <Container maxWidth="sm">
            <fieldset>
              <legend>Detail:</legend>
              <AppBar position="static" color="default">
                <Tabs
                  value={tabId}
                  onChange={handleChange}
                  indicatorColor="primary"
                  textColor="primary"
                  variant="fullWidth"
                  aria-label="full width tabs example"
                >
                  {langs.map(e => {
                    return (
                      <Tab label={e.name} key={e.id} />
                    );
                  })}
                </Tabs>
              </AppBar>
              <Box >
                <SwipeableViews
                  className={classes.root}
                  axis={theme.direction === 'rtl' ? 'x-reverse' : 'x'}
                  index={tabId}
                  onChangeIndex={handleChangeIndex}
                >
                  {langs.map((e, i) => {
                    return (
                      <TabPanel value={tabId} index={i} dir={theme.direction} key={e.id}>
                        <InputField name={`data.details.${i}.name`} control={control} label={`Category name`} />
                        <InputField name={`data.details.${i}.description`} control={control} label={`Category description`} />
                      </TabPanel>
                    );
                  })}
                </SwipeableViews>
              </Box >
            </fieldset>
          </Container>
        </form>
      </Dialog>
    </>
  );
}
