import { Paper, TableContainer } from "@material-ui/core";
import { useAppDispatch, useAppSelector } from "app/hooks";
import { MaxGridFooter } from "components/Common";
import { MaxGridHeader } from "components/Common/MaxGrid/MaxGridHeader";
import * as React from "react";
import { useEffect } from "react";
import {
  categoryActions,
  selectCategoryTable,
  selectCategoryTablePagination,
  selectFilterCategoryRequest,
} from "./categorySlice";
import CategoryForm from "./components/CategoryForm";
import { CategoryTable } from "./components/CategoryTable";

export interface ICategoryProps {}

export const Category: React.FunctionComponent<ICategoryProps> = (props) => {
  const filter = useAppSelector(selectFilterCategoryRequest);
  const pagination = useAppSelector(selectCategoryTablePagination);
  const dispatch = useAppDispatch();
  const [openModal, setOpenModal] = React.useState<boolean>(false);

  const handleCloseForm = () => {
    setOpenModal(false);
  };

  const addCategory = () => {
    dispatch(categoryActions.fetchCategoryAdd());
    setOpenModal(true);
  };

  const tableCategories = useAppSelector(selectCategoryTable);
  useEffect(() => {
    dispatch(categoryActions.fetchCategories(filter));
  }, [dispatch, filter]);

  const categoryForm = React.useMemo(() => {
    return (
      <CategoryForm
        openModal={openModal}
        onClose={handleCloseForm}
      ></CategoryForm>
    );
  }, [openModal]);

  const handleEditItem = React.useCallback(
    (categoryId: number | undefined) => {
      dispatch(categoryActions.fetchCategoryUpdate(categoryId));
      setOpenModal(true);
    },
    [dispatch]
  );

  const handleChangePage = (event: any, newPage: number) => {
    if (pagination.pageIndex != newPage)
      dispatch(
        categoryActions.setFilter({
          key: "pagination.pageIndex",
          value: newPage,
        })
      );
  };

  return (
    <>
      <TableContainer component={Paper}>
        {/* Header */}
        <MaxGridHeader
          onSearch={(event) => event.preventDefault()}
          onAdd={addCategory}
          placeholderSearch="placeholder Search"
        />
        <CategoryTable
          tableCategories={tableCategories}
          onEdit={handleEditItem}
          onDelete={(id) => {}}
        />
        {/* Pagination */}
        <MaxGridFooter
          pagination={pagination}
          onChangePageIndex={handleChangePage}
        />
      </TableContainer>

      {/* edit/add */}
      {categoryForm}
    </>
  );
};
