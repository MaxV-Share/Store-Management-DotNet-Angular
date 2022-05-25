import {
  IconButton,
  makeStyles,
  Table,
  TableBody,
  TableCell,
  TableRow,
  Tooltip,
  Zoom,
} from "@material-ui/core";
import DeleteIcon from "@material-ui/icons/Delete";
import EditIcon from "@material-ui/icons/Edit";
import { useAppDispatch, useAppSelector } from "app/hooks";
import { MaxTableHeader } from "components/Common";
import { ISortDescriptor } from "models";
import { IMaxColumn } from "models/Common";
import * as React from "react";
import { categoryActions, selectFilterCategoryRequest } from "../categorySlice";

const useStyles = makeStyles((theme) => ({
  table: {},
  edit: {
    marginRight: theme.spacing(1),
  },
  appBar: {
    position: "relative",
  },
  title: {
    marginLeft: theme.spacing(2),
    flex: 1,
  },
  root: {
    "& .MuiTextField-root": {
      margin: theme.spacing(1),
      width: "25ch",
    },
  },
  visuallyHidden: {
    border: 0,
    clip: "rect(0 0 0 0)",
    height: 1,
    margin: -1,
    overflow: "hidden",
    padding: 0,
    position: "absolute",
    top: 20,
    width: 1,
  },
}));

const columns: IMaxColumn[] = [
  { key: "no", label: "No" },
  { key: "name", label: "Name", isSortable: true },
  { key: "description", label: "Description", isSortable: true },
  {
    key: "actions",
    label: "Actions",
    isSortable: false,
    headerClassName: "MuiTableCell-alignRight",
  },
];

export interface ICategoryTableProps {
  tableCategories: any;
  onEdit: (id?: number) => void;
  onDelete?: (id?: number) => void;
}
export function CategoryTable({
  tableCategories,
  onEdit,
  onDelete,
}: ICategoryTableProps) {
  const classes = useStyles();
  const dispatch = useAppDispatch();
  const filterCategoryRequest = useAppSelector(selectFilterCategoryRequest);

  const handleSortTable = (key: string) => {
    let sort: ISortDescriptor = {
      field: key,
      direction: "asc",
    };
    if (filterCategoryRequest.orders?.length) {
      sort.direction =
        filterCategoryRequest.orders?.[0].direction == "asc" ? "desc" : "asc";
    }
    if (
      filterCategoryRequest.orders?.length &&
      filterCategoryRequest.orders?.[0].direction == "desc"
    ) {
      dispatch(categoryActions.setFilter({ key: `orders`, value: [] }));
    } else {
      dispatch(categoryActions.setFilter({ key: `orders.${0}`, value: sort }));
    }
  };

  const tableBodyCategory = React.useMemo(() => {
    return tableCategories.data.map((c: any, i: any) => (
      <TableRow key={i}>
        <TableCell>{i + 1}</TableCell>
        <TableCell>{c["name"]}</TableCell>
        <TableCell>{c.description}</TableCell>
        <TableCell align="right">
          <Tooltip
            title="Edit"
            TransitionComponent={Zoom}
            onClick={() => onEdit?.(c.categoryId)}
          >
            <IconButton color="primary" aria-label="edit" size="small">
              <EditIcon />
            </IconButton>
          </Tooltip>

          <Tooltip
            title="Delete"
            TransitionComponent={Zoom}
            onClick={() => onDelete?.(c.categoryId)}
          >
            <IconButton color="secondary" aria-label="delete" size="small">
              <DeleteIcon />
            </IconButton>
          </Tooltip>
        </TableCell>
      </TableRow>
    ));
  }, [tableCategories]);

  return (
    <>
      <Table className={classes.table} size="small" aria-label="simple table">
        <MaxTableHeader
          columns={columns}
          orders={filterCategoryRequest.orders}
          onSort={handleSortTable}
        />
        <TableBody>{tableBodyCategory}</TableBody>
      </Table>
    </>
  );
}
