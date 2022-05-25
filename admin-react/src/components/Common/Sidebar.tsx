import List from "@material-ui/core/List";
import ListItem from "@material-ui/core/ListItem";
import ListItemIcon from "@material-ui/core/ListItemIcon";
import ListItemText from "@material-ui/core/ListItemText";
import { makeStyles } from "@material-ui/core/styles";
import * as Icons from '@material-ui/icons/';
import React from "react";
import { NavLink } from "react-router-dom";

const useStyles = makeStyles((theme) => ({
  root: {
    width: "100%",
    maxWidth: 360,
    backgroundColor: theme.palette.background.paper,
  },
  link: {
    color: "inherit",
    textDecoration: "none",

    "&.active > div": {
      backgroundColor: theme.palette.action.selected,
    },
  },
}));

export function Sidebar() {
  const classes = useStyles();

  return (
    <div className={classes.root}>
      <List component="nav" aria-label="main mailbox folders">
        <NavLink to="/admin/dashboard" className={classes.link}>
          <ListItem button>
            <ListItemIcon>
              {React.createElement(Icons['Dashboard'])}
            </ListItemIcon>
            <ListItemText primary="Dashboard" />
          </ListItem>
        </NavLink>

        <NavLink to="/admin/product-category" className={classes.link}>
          <ListItem button>
            <ListItemIcon>
              {React.createElement(Icons['PeopleAlt'])}
            </ListItemIcon>
            <ListItemText primary="ProductCategory" />
          </ListItem>
        </NavLink>

        <NavLink to="/admin/category" className={classes.link}>
          <ListItem button>
            <ListItemIcon>
              {React.createElement(Icons['PeopleAlt'])}
            </ListItemIcon>
            <ListItemText primary="Category" />
          </ListItem>
        </NavLink>

        <NavLink to="/admin/function" className={classes.link}>
          <ListItem button>
            <ListItemIcon>
              {React.createElement(Icons['Dashboard'])}
            </ListItemIcon>
            <ListItemText primary="Function" />
          </ListItem>
        </NavLink>
      </List>
    </div>
  );
}
