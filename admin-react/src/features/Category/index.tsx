import { Box } from '@material-ui/core';
import { Pagination } from '@material-ui/lab';
import { useAppDispatch, useAppSelector } from 'app/hooks';
import * as React from 'react';
import { useEffect } from 'react';
import { categoryActions, selectCategories, selectCategoryFilter, selectCategoryPagination } from './categorySlice';
import { CategoryTable } from './components/CategoryTable';

export interface ICategoryProps {
}

export function Category(props: ICategoryProps) {


  const filter = useAppSelector(selectCategoryFilter);
  const pagination = useAppSelector(selectCategoryPagination);
  const dispatch = useAppDispatch();

  const categories = useAppSelector(selectCategories);
  useEffect(() => {
    dispatch(categoryActions.fetchCategories(filter));
  }, [dispatch]);

  const handlePageChange = () => {
    console.log("ád")
  }

  return (
    <div>
      <CategoryTable categories={categories}></CategoryTable>

      {/* Pagination */}
      <Box my={2} display="flex" justifyContent="center">
        <Pagination
          color="primary"
          count={pagination.pageCount}
          page={pagination.pageIndex}
          onChange={handlePageChange}
        />
      </Box>
    </div>
  );
}
