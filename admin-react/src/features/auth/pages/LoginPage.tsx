import { Box, Button, CircularProgress, makeStyles, Paper, Typography } from '@material-ui/core';
import * as React from 'react';
import { useAppDispatch, useAppSelector } from '../../../app/hooks';
import { authActions } from '../authSlice';

const useStyles = makeStyles((theme) => ({
    root: {
        display: 'flex',
        flexFlow: 'row nowrap',
        justifyContent: 'center',
        alignItems: 'center',
        minHeight: '100vh',
    },

    box: {
        padding: theme.spacing(3),
    },
}));

export interface ILoginPageProps {
}

export default function LoginPage(props: ILoginPageProps) {
    const classes = useStyles();
    const dispatch = useAppDispatch();
    const isLogging = useAppSelector((state) => state.auth.logging);
    const handleLoginCLick = () => {
        dispatch(authActions.login({
            username: '',
            password: '',
        }))
    }
    return (
        <div className={classes.root}>
            <Paper elevation={3} className={classes.box}>
                <Typography variant="h5" component="h1">
                    Student Management
                </Typography>

                <Box mt={4}>
                    <Button fullWidth variant="contained" color="primary" onClick={handleLoginCLick}>
                        {isLogging && <CircularProgress size={20} color="secondary" />} &nbsp; Fake Login
                    </Button>
                </Box>
            </Paper>
        </div>
    );
}

