import { AppBar, Button, Dialog, IconButton, makeStyles, Slide, Toolbar, Typography } from '@material-ui/core';
import { TransitionProps } from '@material-ui/core/transitions';
import CloseIcon from '@material-ui/icons/Close';
import * as React from 'react';

export interface IMaxFormDialogProps {
  children?: React.ReactNode;
  onClose: () => void;
  onSubmit: () => void;
  open: boolean;
  title: string;
}
const useStyles = makeStyles((theme) => ({
  appBar: {
    position: 'relative',
  },
  title: {
    marginLeft: theme.spacing(2),
    flex: 1,
  },
}));

export const Transition = React.forwardRef(function Transition(
  props: TransitionProps & { children?: React.ReactElement },
  ref: React.Ref<unknown>,
) {
  return <Slide direction="left" ref={ref} {...props} />;
});

export function MaxFormDialog({ children, onClose, onSubmit, open, title }: IMaxFormDialogProps) {
  const classes = useStyles();
  return (
    <Dialog fullScreen open={open} onClose={onClose} TransitionComponent={Transition}>
      <AppBar className={classes.appBar}>
        <Toolbar>
          <IconButton edge="start" color="inherit" onClick={onClose} aria-label="close">
            <CloseIcon />
          </IconButton>
          <Typography variant="h6" className={classes.title}>
            {title}
          </Typography>
          <Button autoFocus color="inherit" type="submit" onClick={onSubmit}>
            save
          </Button>
        </Toolbar>
      </AppBar>
      {children}
    </Dialog>
  );
}
