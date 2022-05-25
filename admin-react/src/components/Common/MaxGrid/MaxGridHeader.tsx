import { Box, createStyles, Fab, IconButton, Input, makeStyles, Paper, Theme, Tooltip } from '@material-ui/core';
import AddIcon from '@material-ui/icons/Add';
import SearchIcon from '@material-ui/icons/Search';
import * as React from 'react';

const useStyles = makeStyles((theme: Theme) =>
  createStyles({
    root: {
      padding: "2px 4px",
      display: "flex",
      alignItems: "center",
      width: 400
    },
    input: {
      marginLeft: theme.spacing(1),
      flex: 1
    },
    iconButton: {
      padding: 10
    }
  })
);

export interface IMaxGridHeaderProps {
  placeholderSearch?: string,
  onAdd?: () => void;
  onSearch?: (e: React.MouseEvent<any, any>) => void;
}

export function MaxGridHeader(props: IMaxGridHeaderProps) {
  const classes = useStyles();
  const { placeholderSearch, onAdd, onSearch } = props;
  return (
    <>
      <Box m={1} display="flex" justifyContent="space-between" >
        <Paper component="form" className={classes.root} elevation={0} >
          {
            onSearch == undefined ? null :
              (<>
                <Input
                  className={classes.input}
                  placeholder={placeholderSearch}
                  inputProps={{ "aria-label": "search google maps" }}
                />
                <IconButton
                  type="submit"
                  className={classes.iconButton}
                  aria-label="search"
                  onClick={(event) => {
                    event.preventDefault();
                    onSearch?.(event);
                  }}
                >
                  <SearchIcon />
                </IconButton>
              </>)
          }

        </Paper>
        <Box>
          {
            onAdd == undefined ? null :
              (
                <Tooltip title="Add" aria-label="add">
                  <Fab color="primary" onClick={onAdd}>
                    <AddIcon />
                  </Fab>
                </Tooltip>
              )
          }
        </Box>
      </Box>
    </>
  );
}
