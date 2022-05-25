import { yupResolver } from "@hookform/resolvers/yup";
import {
  AppBar,
  Box,
  Button,
  Container,
  Dialog,
  Grid,
  IconButton,
  makeStyles,
  Tab,
  Tabs,
  Toolbar,
  Typography,
  useTheme,
} from "@material-ui/core";
import CloseIcon from "@material-ui/icons/Close";
import {
  selectGlobalFunctionsByCurrentLangCode,
  selectGlobalFunctionTreeByCurrentLangCode,
  selectGlobalLangs,
} from "app/globalSelector";
import { useAppDispatch, useAppSelector } from "app/hooks";
import { Transition } from "components/Common";
import TabPanel from "components/Common/TabPanel";
import { InputField, MuiAutocomplete } from "components/FormFields";
import {
  IBaseAddOrUpdateBodyRequest,
  IFunctionAddOrUpdateModel,
  IFunctionDetailAddOrUpdateModel,
} from "models";
import { ILangViewModel } from "models/Langs/ILangViewModel";
import * as React from "react";
import { useEffect } from "react";
import { useForm } from "react-hook-form";
import SwipeableViews from "react-swipeable-views";
import * as yup from "yup";
import { selectFunctionAddOrUpdateData } from "../functionSelectors";
import { functionActions } from "../functionSlice";

export interface IAddOrEditFunctionFormProps {
  openModal: boolean;
  onClose: () => void;
  isEdit?: boolean;
}
const schema = yup.object().shape({
  data: yup.object().shape({
    details: yup.array().of(
      yup.object().shape({
        name: yup.string().required("Please enter name."),
      })
    ),
  }),
});

const useStyles = makeStyles((theme) => ({
  appBar: {
    position: "relative",
  },
  title: {
    marginLeft: theme.spacing(2),
    flex: 1,
  },
  root: {
    "& .MuiTextField-root": {
      margin: theme.spacing(1),
      width: "25ch",
    },
  },
}));

export function AddOrEditFunctionForm(props: IAddOrEditFunctionFormProps) {
  const { openModal, onClose: handleCloseForm, isEdit } = props;
  const classes = useStyles();
  const theme = useTheme();
  const [tabId, setTabId] = React.useState(0);
  const langs = useAppSelector(selectGlobalLangs);
  const dispatch = useAppDispatch();
  const functions = useAppSelector(selectGlobalFunctionsByCurrentLangCode);
  const functionTree = useAppSelector(
    selectGlobalFunctionTreeByCurrentLangCode
  );
  useEffect(() => {
    console.log("functionTree", functionTree);
  }, [functionTree]);
  const {
    control,
    handleSubmit,
    reset,
    formState: { isSubmitting, errors },
    setValue,
  } = useForm<IBaseAddOrUpdateBodyRequest<IFunctionAddOrUpdateModel>, object>({
    defaultValues: {
      data: {
        details: [],
      },
    },
    resolver: yupResolver(schema),
  });

  const functionAddOrUpdateData = useAppSelector(selectFunctionAddOrUpdateData);
  useEffect(() => {
    reset({ data: functionAddOrUpdateData });
  }, [functionAddOrUpdateData, openModal]);

  useEffect(() => {
    reset({
      data: {
        details: langs.map<IFunctionDetailAddOrUpdateModel>(
          (e: ILangViewModel) => {
            return {
              langId: e.id,
              name: "",
            };
          }
        ),
      },
    });
  }, [dispatch, langs]);
  const handleClose = () => {
    reset({});
    handleCloseForm();
  };

  const handleChange = (event: React.ChangeEvent<{}>, newValue: number) => {
    setTabId(newValue);
  };

  const handleChangeIndex = (index: number) => {
    setTabId(index);
  };

  const handleFormSubmit = (
    formValues: IBaseAddOrUpdateBodyRequest<IFunctionAddOrUpdateModel>
  ) => {
    try {
      console.log("handleFormSubmit", formValues.data);
      dispatch(functionActions.add(formValues.data));
      handleClose();
    } catch (error: any) {
      // setError(error.message);
    }
  };

  return (
    <>
      <Dialog
        fullScreen
        open={openModal}
        onClose={handleClose}
        TransitionComponent={Transition}
      >
        <form onSubmit={handleSubmit(handleFormSubmit)}>
          <AppBar className={classes.appBar}>
            <Toolbar>
              <IconButton
                edge="start"
                color="inherit"
                onClick={handleClose}
                aria-label="close"
              >
                <CloseIcon />
              </IconButton>
              <Typography variant="h6" className={classes.title}>
                {isEdit ? "Edit" : "Add"} Function Detail
              </Typography>
              <Button autoFocus color="inherit" type="submit">
                save
              </Button>
            </Toolbar>
          </AppBar>
          <Container maxWidth="md">
            <Grid container>
              <Grid item xs={6}>
                <Box px={1}>
                  <InputField
                    name={`data.id`}
                    control={control}
                    label={`Code`}
                  />
                </Box>
              </Grid>
              <Grid item xs={6}>
                <Box px={1}>
                  <InputField
                    name={`data.url`}
                    control={control}
                    label={`Url`}
                  />
                </Box>
              </Grid>
              <Grid item xs={6}>
                <Box px={1}>
                  <InputField
                    name={`data.icon`}
                    control={control}
                    label={`Icon`}
                  />
                </Box>
              </Grid>
              <Grid item xs={6}>
                <Box px={1}>
                  <InputField
                    name={`data.sortOrder`}
                    control={control}
                    label={`Sort Order`}
                    type="number"
                  />
                </Box>
              </Grid>
              <Grid item xs={6}>
                <Box px={1}>
                  <MuiAutocomplete
                    fieldDisplay="name"
                    label="Parent"
                    name="data.parent"
                    onChange={(e) => {
                      setValue("data.parentId", e?.id);
                    }}
                    control={control}
                    defaultValue={functions[0]}
                    data={functions}
                  />
                </Box>
              </Grid>
            </Grid>

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
                  {langs.map((e) => {
                    return <Tab label={e.name} key={e.id} />;
                  })}
                </Tabs>
              </AppBar>
              <Box>
                <SwipeableViews
                  className={classes.root}
                  axis={theme.direction === "rtl" ? "x-reverse" : "x"}
                  index={tabId}
                  onChangeIndex={handleChangeIndex}
                >
                  {langs.map((e, i) => {
                    return (
                      <TabPanel
                        value={tabId}
                        index={i}
                        dir={theme.direction}
                        key={e.id}
                      >
                        <InputField
                          name={`data.details.${i}.name`}
                          control={control}
                          label={`Category name`}
                        />
                      </TabPanel>
                    );
                  })}
                </SwipeableViews>
              </Box>
            </fieldset>
          </Container>
        </form>
      </Dialog>
    </>
  );
}
