import categoryApi from 'api/categoryApi';
import { useAppDispatch } from 'app/hooks';
import { IFilterBodyRequest } from 'models/Bases/IFilterBodyRequest';
import * as React from 'react';
import { useEffect } from 'react';
import { categoryActions } from './categorySlice';
import { CategoryTable } from './components/CategoryTable';

export interface ICategoryProps {
}

export function Category(props: ICategoryProps) {


  //const filter = useAppSelector(selectCategoryFilter);

  let request: IFilterBodyRequest = {
    pagination: {
      pageIndex: 1,
      pageSize: 10,
    },
    langId: "EN",
    searchValue: "",
  }
  categoryApi.getAll(request);

  const dispatch = useAppDispatch();

  useEffect(() => {
    dispatch(categoryActions.fetchCategories(request));
  }, [dispatch]);
  return (
    <div>
      <CategoryTable></CategoryTable>
    </div>
  );
}
