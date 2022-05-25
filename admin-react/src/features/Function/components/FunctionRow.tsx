import {
  Box,
  Collapse,
  IconButton,
  makeStyles,
  TableCell,
  TableRow,
  Tooltip,
  Zoom,
} from "@material-ui/core";
import DeleteIcon from "@material-ui/icons/Delete";
import EditIcon from "@material-ui/icons/Edit";
import KeyboardArrowDownIcon from "@material-ui/icons/KeyboardArrowDown";
import KeyboardArrowRightIcon from "@material-ui/icons/KeyboardArrowRight";
import { IFunctionFullModel } from "models";
import * as React from "react";

const useRowStyles = makeStyles({
  root: {
    "& > *": {
      borderBottom: "unset",
    },
  },
});

interface IFunctionRowProps {
  data: IFunctionFullModel;
  index?: any;
  onEdit?: (id?: string) => void;
  onDelete?: (id?: string) => void;
}

const FunctionRow: React.FunctionComponent<IFunctionRowProps> = (props) => {
  const { data, index, onEdit, onDelete } = props;
  const [open, setOpen] = React.useState(false);
  const classes = useRowStyles();

  // const tableBodyChild = React.useMemo(() => {
  //   return data..map((c, i) => (
  //     <FunctionRow data={c} index={i + 1}></FunctionRow>
  //   ));
  // }, [data]);
  return (
    <>
      <TableRow key={index}>
        <TableCell className={classes.root}>
          <IconButton
            aria-label="expand row"
            size="small"
            onClick={() => setOpen(!open)}
          >
            {open ? <KeyboardArrowDownIcon /> : <KeyboardArrowRightIcon />}
          </IconButton>
        </TableCell>
        <TableCell>{index}</TableCell>
        <TableCell>{data.sortOrder}</TableCell>
        <TableCell>{data.icon}</TableCell>
        <TableCell></TableCell>
        <TableCell align="right">
          <Tooltip
            title="Edit"
            TransitionComponent={Zoom}
            onClick={() => onEdit?.(data.id)}
          >
            <IconButton color="primary" aria-label="edit" size="small">
              <EditIcon />
            </IconButton>
          </Tooltip>

          <Tooltip
            title="Delete"
            TransitionComponent={Zoom}
            onClick={() => onDelete?.(data.id)}
          >
            <IconButton color="secondary" aria-label="delete" size="small">
              <DeleteIcon />
            </IconButton>
          </Tooltip>
        </TableCell>
      </TableRow>
      <TableRow>
        <TableCell style={{ paddingBottom: 0, paddingTop: 0 }} colSpan={6}>
          <Collapse in={open} timeout="auto" unmountOnExit>
            <Box margin={1}>Children</Box>
          </Collapse>
        </TableCell>
        {/* <TableCell>{index}</TableCell>
        <TableCell>{index}</TableCell>
        <TableCell>{data.sortOrder}</TableCell>
        <TableCell>{data.icon}</TableCell>
        <TableCell></TableCell>
        <TableCell></TableCell> */}
      </TableRow>
    </>
  );
};

export default FunctionRow;
