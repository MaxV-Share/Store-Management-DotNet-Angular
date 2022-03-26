import { createStyles, makeStyles, TableCell, TableHead, TableRow, TableSortLabel, Theme } from '@material-ui/core';
import { ISortDescriptor } from 'models';
import { IMaxColumn } from 'models/Common';
import * as React from 'react';

const useStyles = makeStyles((theme: Theme) =>
  createStyles({
    root: {
      width: '100%',
    },
    paper: {
      width: '100%',
      marginBottom: theme.spacing(2),
    },
    table: {
      minWidth: 750,
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
  }),
);

export interface IMaxTableHeaderProps {
  columns: IMaxColumn[],
  orders?: ISortDescriptor[];
  onSort?: (key: string) => void;
}

export function MaxTableHeader(props: IMaxTableHeaderProps) {
  const { columns, orders, onSort } = props;
  const classes = useStyles();
  return (
    <TableHead>
      <TableRow>
        {columns.map(column => {

          let order = orders?.find(e => e.field == column.key);
          return (
            <TableCell
              key={column.key}
              // align={'center'}
              className={column.headerClassName}
              padding={'normal'}
              sortDirection={order?.field === column.key ? order?.direction : false}
            >
              {
                column.isSortable ?
                  (<TableSortLabel
                    active={order?.field === column.key}
                    direction={order?.field === column.key ? order?.direction : undefined}
                    onClick={() => onSort?.(column.key)}
                  >
                    {order?.field === column.key ? (
                      <span className={classes.visuallyHidden}>
                        {order?.direction === 'desc' ? 'sorted descending' : 'sorted ascending'}
                      </span>
                    ) : null}
                    {column.label}

                  </TableSortLabel>
                  ) :
                  (column.label)
              }
            </TableCell>
          )
        })}
      </TableRow>
    </TableHead >
  );
}
