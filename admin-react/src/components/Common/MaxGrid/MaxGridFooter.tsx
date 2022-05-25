// import { Box } from "@material-ui/core";
import Box from "@material-ui/core/Box";
import { Pagination } from "@material-ui/lab";
import { IPagination } from "models";
import * as React from "react";

export interface IMaxGridFooterProps {
  pagination: IPagination;
  onChangePageIndex: (event: React.ChangeEvent<unknown>, page: number) => void;
}

export function MaxGridFooter(props: IMaxGridFooterProps) {
  const { pagination, onChangePageIndex } = props;
  return (
    <>
      <Box m={1} display="flex" justifyContent="space-between">
        <div style={{ display: "flex", justifyContent: "center" }}>
          <p style={{ margin: "0px" }}>PageSize: {pagination?.pageSize}</p>
        </div>
        <Pagination
          color="primary"
          count={pagination?.pageCount}
          page={pagination?.pageIndex}
          onChange={onChangePageIndex}
        />
      </Box>
    </>
  );
}
