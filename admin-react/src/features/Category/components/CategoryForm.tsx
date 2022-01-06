import { yupResolver } from '@hookform/resolvers/yup';
import { AppBar, Box, Button, Container, Dialog, IconButton, makeStyles, Tab, Tabs, Toolbar, Typography, useTheme } from '@material-ui/core';
import CloseIcon from '@material-ui/icons/Close';
import { useAppSelector } from 'app/hooks';
import { Transition } from 'components/Common';
import TabPanel from 'components/Common/TabPanel';
import { InputField } from 'components/FormFields';
import { selectCityOptions } from 'features/city/citySlice';
import { IBaseAddOrUpdateBodyRequest, ICategoryViewModel } from 'models';
import React, { useEffect, useState } from 'react';
import { useForm } from 'react-hook-form';
import SwipeableViews from 'react-swipeable-views';
import * as yup from 'yup';
import { selectLangs } from '../categorySlice';

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
  // initialValues?: ICategoryViewModel;
  // control: Control<ICategoryViewModel, object>;
  // onSubmit?: (formValues: ICategoryViewModel) => void;
}

const schema = yup.object().shape({
  data: yup.array().of(yup.object().shape({
    name: yup
      .string()
      .required('Please enter name.')
  }))
});

export default function CategoryForm({ }: CategoryFormProps) {
  const cityOptions = useAppSelector(selectCityOptions);
  const [error, setError] = useState<string>('');
  const classes = useStyles();
  const theme = useTheme();
  const [open, setOpen] = useState(false);
  const [value, setValue] = React.useState(0);
  const langs = useAppSelector(selectLangs);

  const handleClose = () => {
    setOpen(false);
  };

  const { control,
    handleSubmit,
    formState: { isSubmitting, errors }, } = useForm<IBaseAddOrUpdateBodyRequest<ICategoryViewModel[]>, object>({
      defaultValues: {
        data: [{
          name: '',
        }, {
          name: '',
        }
        ]
      },
      resolver: yupResolver(schema),
    });

  useEffect(() => {
    console.log(errors);
  }, [errors])
  const handleRemoveConfirm = (category: ICategoryViewModel) => {
    // onRemove?.(student);
    setOpen(false);
  };
  const onClose = () => {
    setOpen(false);
  }

  const handleSubmitDialog = () => {

  }
  const addCategory = () => {
    setOpen(true);
  };

  const handleSaveCategory = (category: ICategoryViewModel) => {
    setOpen(false);
  };

  const handleFormSubmit = async (formValues: IBaseAddOrUpdateBodyRequest<ICategoryViewModel[]>) => {
    try {
      // Clear previous submission error
      setError('');
      console.log(formValues);
      // await onSubmit?.(formValues);
    } catch (error: any) {
      setError(error.message);
    }
  };

  const handleChange = (event: React.ChangeEvent<{}>, newValue: number) => {
    setValue(newValue);
  };

  const handleChangeIndex = (index: number) => {
    setValue(index);
  };
  return (
    <>
      <Button variant="outlined" color="primary" onClick={addCategory}>
        Add Category
      </Button>
      <Dialog fullScreen open={open} onClose={onClose} TransitionComponent={Transition}>
        <Button autoFocus color="inherit" type="submit" onClick={handleSubmit(handleFormSubmit)}>
          Test
        </Button>
        <form onSubmit={handleSubmit(handleFormSubmit)}>
          <AppBar className={classes.appBar}>
            <Toolbar>
              <IconButton edge="start" color="inherit" onClick={onClose} aria-label="close">
                <CloseIcon />
              </IconButton>
              <Typography variant="h6" className={classes.title}>
                Category Detail
              </Typography>
              <Button autoFocus color="inherit" type="submit" >
                save
              </Button>
            </Toolbar>
          </AppBar>
          <Container maxWidth="sm">
            <fieldset>
              <legend>Personalia:</legend>
              <AppBar position="static" color="default">
                <Tabs
                  value={value}
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
                  index={value}
                  onChangeIndex={handleChangeIndex}
                >
                  {langs.map((e, i) => {
                    return (
                      <TabPanel value={value} index={i} dir={theme.direction} key={e.id}>
                        <InputField name={`data.${i}.name`} control={control} label={`Category name`} />
                        <InputField name={`data.${i}.description`} control={control} label={`Category description`} />
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
