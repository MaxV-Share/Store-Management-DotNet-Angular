import {
  FormControl,
  FormHelperText,
  makeStyles,
  TextField,
} from "@material-ui/core";
import { Autocomplete } from "@material-ui/lab";
import React, { InputHTMLAttributes } from "react";
import { Control, Controller } from "react-hook-form";

export interface AutocompleteFieldProps
  extends InputHTMLAttributes<HTMLInputElement> {
  onChange: (data: any) => void;
  control: Control<any>;
  data: any[];
  defaultValue?: any;
  fieldDisplay: string;
  label: string;
  name: string;
}

const useStyles = makeStyles((theme) => ({
  margin: {
    margin: theme.spacing(1),
  },
}));

export function MuiAutocomplete({
  onChange,
  control,
  data,
  defaultValue,
  fieldDisplay,
  label,
  name,
  ...inputProps
}: AutocompleteFieldProps) {
  const classes = useStyles();
  return (
    <>
      {/* <InputLabel id={`${name}_label`}>{label}</InputLabel> */}
      <Controller
        render={({
          field: { value, onBlur, ref, name: fieldName },
          fieldState: { invalid, error },
        }) => (
          <FormControl
            fullWidth
            variant="outlined"
            error={invalid}
            size="small"
            className={classes.margin}
          >
            <Autocomplete
              options={data}
              getOptionLabel={(option) => option[fieldDisplay]}
              renderOption={(option) => <span>{option[fieldDisplay]}</span>}
              defaultValue={defaultValue}
              renderInput={(params) => (
                <TextField {...params} label={label} variant="outlined" />
              )}
              onChange={(e, data) => {
                onChange(data);
              }}
              // {...props}
            />
            <FormHelperText id="component-error-text">
              {error?.message}
            </FormHelperText>
          </FormControl>
        )}
        name={name}
        control={control}
      />
      {/* <Autocomplete
          options={data}
          getOptionLabel={(option) => option[fieldDisplay]}
          renderOption={(option) => <span>{option[fieldDisplay]}</span>}
          defaultValue={defaultValue}
          renderInput={(params) => (
            <TextField {...params} label={label} variant="outlined" />
          )}
          onChange={(e, data) => {
            console.log(data);
            // return onChangeController(data);
          }}
        /> */}
    </>
  );
}
