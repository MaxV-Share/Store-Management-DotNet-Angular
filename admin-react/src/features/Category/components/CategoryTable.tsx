import { Button, makeStyles, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from '@material-ui/core';
import { ICategoryViewModel } from 'models';
import * as React from 'react';
import { useState } from 'react';
import * as yup from 'yup';
import CategoryForm from './CategoryForm';


const useStyles = makeStyles((theme) => ({
  table: {},
  edit: {
    marginRight: theme.spacing(1),
  },
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


const schema = yup.array().of(yup.object().shape({
  name: yup
    .string()
    .required('Please enter name.')
    .test('two-words', 'Please enter at least two words', (value) => {
      if (!value) return true;

      const parts = value?.split(' ') || [];
      return parts.filter((x) => Boolean(x)).length >= 2;
    }),
  age: yup
    .number()
    .positive('Please enter a positive number.')
    .min(18, 'Min is 18')
    .max(60, 'Max is 60')
    .integer('Please enter an integer.')
    .required('Please enter age.')
    .typeError('Please enter a valid number.'),
  mark: yup
    .number()
    .min(0, 'Min is 0')
    .max(10, 'Max is 10')
    .required('Please enter mark.')
    .typeError('Please enter a valid number.'),
  gender: yup
    .string()
    .oneOf(['male', 'female'], 'Please select either male or female.')
    .required('Please select gender.'),
  city: yup.string().required('Please select city.'),
}));

export interface ICategoryTableProps {
  categories: ICategoryViewModel[];
}
export function CategoryTable({ categories }: ICategoryTableProps) {

  const classes = useStyles();
  const [selectedStudent, setSelectedStudent] = useState<ICategoryViewModel>();

  const tableBodyCategory = React.useMemo(() => {
    return (categories.map((c, i) => (
      <TableRow key={i}>
        <TableCell>{i + 1}</TableCell>
        <TableCell>{c.name}</TableCell>
        <TableCell>{c.description}</TableCell><TableCell align="right">
          <Button
            className={classes.edit}
            size="small"
            color="primary"
          // onClick={() => handleSaveCategory?.(c)}
          >
            Edit
          </Button>

          {/* <Button size="small" color="secondary" onClick={() => handleRemoveClick(c)}>
            Remove
          </Button> */}
        </TableCell>
      </TableRow>
    )))
  }, [categories]);

  return (
    <>
      <TableContainer component={Paper}>
        <Table className={classes.table} size="small" aria-label="simple table">
          <TableHead>
            <TableRow>
              <TableCell>No</TableCell>
              <TableCell>Name</TableCell>
              <TableCell>description</TableCell>
              <TableCell align="right">Actions</TableCell>
            </TableRow>
          </TableHead>

          <TableBody>
            {tableBodyCategory}
          </TableBody>
        </Table>
      </TableContainer>

      {/* edit/add */}
      <CategoryForm></CategoryForm>
    </>
  );
}

