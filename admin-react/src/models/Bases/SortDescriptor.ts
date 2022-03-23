import { MaxSortDirection } from "models/Common";

export interface ISortDescriptor {
  field: string,
  direction?: MaxSortDirection
}