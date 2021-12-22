import { Box, makeStyles } from "@material-ui/core";
import Dashboard from "features/dashboard";
import StudentFeature from "features/student";
import * as React from "react";
import { Route, Switch } from "react-router-dom";
import ProductCategory from '../../features/ProductCategory';
import { Sidebar } from "../Common";
import { Header } from "../Common/Header";

export interface IAdminLayoutProps { }
const useStyles = makeStyles((theme) => ({
  root: {
    display: "grid",
    gridTemplateRows: "auto 1fr",
    gridTemplateColumns: "240px 1fr",
    gridTemplateAreas: `"header header" "sidebar main"`,

    minHeight: "100vh",
  },

  header: {
    gridArea: "header",
  },
  sidebar: {
    gridArea: "sidebar",
    borderRight: `1px solid ${theme.palette.divider}`,
    backgroundColor: theme.palette.background.paper,
  },
  main: {
    gridArea: "main",
    backgroundColor: theme.palette.background.paper,
    padding: theme.spacing(2, 3),
  },
}));

export function AdminLayout(props: IAdminLayoutProps) {
  const classes = useStyles();
  return (
    <Box className={classes.root}>
      <Box className={classes.header}>
        <Header />
      </Box>

      <Box className={classes.sidebar}>
        <Sidebar />
      </Box>

      <Box className={classes.main}>
        <Switch>
          <Route path="/admin/dashboard">
            <Dashboard />
          </Route>

          <Route path="/admin/students">
            <StudentFeature />
          </Route>

          <Route path="/admin/product-category">
            <ProductCategory />
          </Route>
        </Switch>
      </Box>
    </Box>
  );
}
