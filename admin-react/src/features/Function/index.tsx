import { Paper, TableContainer } from "@material-ui/core";
import { Button } from "antd";
import { useAppDispatch, useAppSelector } from "app/hooks";
import { MaxGridFooter } from "components/Common";
import { MaxGridHeader } from "components/Common/MaxGrid/MaxGridHeader";
import React, { useEffect } from "react";
import { AddOrEditFunctionForm } from "./components/AddOrEditFunctionForm";
import { FunctionTable } from "./components/FunctionTable";
import {
  selectFilterFunctionRequest,
  selectFunctionTable,
  selectFunctionTablePagination,
} from "./functionSelectors";
import { functionActions } from "./functionSlice";

export interface IFunctionProps {}

export function Function(props: IFunctionProps) {
  const dispatch = useAppDispatch();
  const [openModal, setOpenModal] = React.useState<boolean>(false);

  const tableFunctions = useAppSelector(selectFunctionTable);
  const filter = useAppSelector(selectFilterFunctionRequest);
  const pagination = useAppSelector(selectFunctionTablePagination);
  useEffect(() => {
    dispatch(functionActions.fetchFunctionDataTable(filter));
  }, [dispatch, filter]);

  const handleCloseForm = () => {
    setOpenModal(false);
  };
  const addFunction = () => {
    // dispatch(categoryActions.fetchCategoryAdd());
    setOpenModal(true);
  };

  const handleChangePage = (event: any, newPage: number) => {
    // if (pagination.pageIndex != newPage)
    //   dispatch(functionActions.setFilter({ key: "pagination.pageIndex", value: newPage }))
  };

  const functionForm = React.useMemo(() => {
    return (
      <AddOrEditFunctionForm openModal={openModal} onClose={handleCloseForm} />
    );
  }, [openModal]);

  return (
    <>
      <Button type="primary">Button</Button>
      <TableContainer component={Paper}>
        {/* Table Header */}
        <MaxGridHeader
          onSearch={(event) => event.preventDefault()}
          onAdd={addFunction}
          placeholderSearch="placeholder Search"
        />
        {/* Table Body */}
        <FunctionTable tableFunctions={tableFunctions} />
        {/* Pagination */}
        <MaxGridFooter
          pagination={pagination}
          onChangePageIndex={handleChangePage}
        />
      </TableContainer>
      {/* {functionForm} */}
    </>
  );
}
