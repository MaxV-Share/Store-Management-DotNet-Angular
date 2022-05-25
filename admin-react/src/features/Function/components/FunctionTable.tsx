import { makeStyles, Table, TableBody } from "@material-ui/core";
import { MaxTableHeader } from "components/Common";
import { IMaxColumn } from "models";
import * as React from "react";
import FunctionRow from "./FunctionRow";

const useStyles = makeStyles((theme) => ({
  table: {},
}));

export interface IFunctionTableProps {
  tableFunctions: any;
  onEdit?: (id?: string) => void;
  onDelete?: (id?: string) => void;
}

const columns: IMaxColumn[] = [
  { key: "extend", label: "" },
  { key: "no", label: "No" },
  { key: "sortOrder", label: "Sort Order", isSortable: true },
  { key: "icon", label: "Icon", isSortable: false },
  { key: "name", label: "Name", isSortable: true },
  {
    key: "actions",
    label: "Actions",
    isSortable: false,
    headerClassName: "MuiTableCell-alignRight",
  },
];

export function FunctionTable({
  tableFunctions,
  onEdit,
  onDelete,
}: IFunctionTableProps) {
  const classes = useStyles();
  const tableBody = React.useMemo(() => {
    return tableFunctions.data.map((c: any, i: any) => (
      <FunctionRow data={c} index={i + 1} key={i + 1}></FunctionRow>
    ));
  }, [tableFunctions]);
  return (
    <>
      <Table size="small" aria-label="simple table">
        <MaxTableHeader
          columns={columns}
          // orders={filterCategoryRequest.orders}
          // onSort={handleSortTable}
        />
        <TableBody>{tableBody}</TableBody>
      </Table>
    </>
  );
}
