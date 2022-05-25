import { Box, makeStyles } from "@material-ui/core";
import * as components from "features";
import { Components, ComponentsEnum } from "models";
import * as React from "react";
import { Route, Switch } from "react-router-dom";
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
console.log('ComponentsEnum', ComponentsEnum)
console.log('Components', Components)
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
          <Route path="/admin/dashboard" component={components['Dashboard']} />
          <Route path="/admin/product-category" component={components['ProductCategory']} />
          <Route path="/admin/category" component={components['Category']} />
          <Route path="/admin/function" component={components['Function']} />
        </Switch>
      </Box>
    </Box>
  );
}
