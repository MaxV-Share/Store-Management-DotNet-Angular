import { IconButton, makeStyles, Table, TableBody, TableCell, TableRow, Tooltip, Zoom } from '@material-ui/core';
import DeleteIcon from '@material-ui/icons/Delete';
import EditIcon from '@material-ui/icons/Edit';
import { GridFilterModel } from '@mui/x-data-grid';
import { GridData } from '@mui/x-data-grid-generator';
import { useAppDispatch, useAppSelector } from 'app/hooks';
import { MaxTableHeader } from 'components/Common';
import { ISortDescriptor } from 'models';
import * as React from 'react';
import * as yup from 'yup';
import { categoryActions, ICategoryTable, selectFilterCategoryRequest } from '../categorySlice';


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
  visuallyHidden: {
    border: 0,
    clip: 'rect(0 0 0 0)',
    height: 1,
    margin: -1,
    overflow: 'hidden',
    padding: 0,
    position: 'absolute',
    top: 20,
    width: 1,
  },
}));


function loadServerRows(page: number, data: GridData): Promise<any> {
  return new Promise<any>((resolve) => {
    setTimeout(() => {
      resolve(data.rows.slice(page * 5, (page + 1) * 5));
    }, Math.random() * 500 + 100); // simulate network latency
  });
}

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
  tableCategories: ICategoryTable;
  onEdit: (id?: number) => void;
  onDelete?: (id?: number) => void;
}
export function CategoryTable({ tableCategories, onEdit, onDelete }: ICategoryTableProps) {
  const classes = useStyles();
  const dispatch = useAppDispatch();
  const filterCategoryRequest = useAppSelector(selectFilterCategoryRequest);

  const handleFilter = (model: GridFilterModel, details?: any) => {
    console.log("handleFilter", model, details);
  }

  const handleSortTable = (key: string) => {
    let sort: ISortDescriptor = {
      field: key,
      direction: 'asc'
    }
    if (filterCategoryRequest.orders?.length) {
      sort.direction = filterCategoryRequest.orders?.[0].direction == 'asc' ? 'desc' : 'asc';
    }
    if (filterCategoryRequest.orders?.length && filterCategoryRequest.orders?.[0].direction == 'desc') {
      dispatch(categoryActions.setFilter({ key: `orders`, value: [] }));
    } else {
      dispatch(categoryActions.setFilter({ key: `orders.${0}`, value: sort }));
    }
  }

  const tableBodyCategory = React.useMemo(() => {
    return (tableCategories.data.map((c, i) => (
      <TableRow key={i}>
        <TableCell>{i + 1}</TableCell>
        <TableCell>{c['name']}</TableCell>
        <TableCell>{c.description}</TableCell><TableCell align="right">
          <Tooltip title="Edit" TransitionComponent={Zoom} onClick={() => onEdit?.(c.id)}>
            <IconButton color='primary' aria-label="edit" size='small'>
              <EditIcon />
            </IconButton>
          </Tooltip>

          <Tooltip title="Delete" TransitionComponent={Zoom} onClick={() => onDelete?.(c.id)}>
            <IconButton color='secondary' aria-label="delete" size='small'>
              <DeleteIcon />
            </IconButton>
          </Tooltip>
        </TableCell>
      </TableRow>
    )))
  }, [tableCategories]);

  return (
    <>
      <Table className={classes.table} size="small" aria-label="simple table">
        <MaxTableHeader
          columns={[{ key: "no", label: "No", disableSort: true }, { key: "name", label: "Name" }, { key: "description", label: "Description" }, { key: "actions", label: "Actions", disableSort: true, headerClassName: 'MuiTableCell-alignRight' },]}
          orders={filterCategoryRequest.orders}
          onSort={handleSortTable}
        />
        <TableBody>
          {tableBodyCategory}
        </TableBody>
      </Table>
    </>
  );
}

