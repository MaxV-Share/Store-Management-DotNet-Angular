import { FormControl, FormHelperText, InputLabel, makeStyles, OutlinedInput } from '@material-ui/core';
import * as React from 'react';
import { InputHTMLAttributes } from 'react';
import { Control, useController } from 'react-hook-form';

const useStyles = makeStyles((theme) => ({
  margin: {
    margin: theme.spacing(1),
  },
}));
export interface InputFieldProps extends InputHTMLAttributes<HTMLInputElement> {
  name: string;
  control: Control<any>;
  label?: string;
}

export function InputField({ name, control, label, ...inputProps }: InputFieldProps) {
  const classes = useStyles();
  const {
    field: { value, onChange, onBlur, ref, name: fieldName },
    fieldState: { invalid, error },
  } = useController({
    name,
    control,
  });

  return (
    <FormControl
      fullWidth
      variant="outlined"
      error={invalid}
      size="small"
      className={classes.margin}
    >
      <InputLabel htmlFor="outlined-adornment-amount">{label}</InputLabel>
      <OutlinedInput
        id="outlined-adornment-amount"
        // startAdornment={<InputAdornment position="start">$</InputAdornment>}
        labelWidth={60} fullWidth
        value={value}
        name={fieldName}
        onChange={onChange}
        onBlur={onBlur}
        label={label}
        inputRef={ref}
        inputProps={inputProps}
      />
      <FormHelperText id="component-error-text">{error?.message}</FormHelperText>
    </FormControl>
  );
}
