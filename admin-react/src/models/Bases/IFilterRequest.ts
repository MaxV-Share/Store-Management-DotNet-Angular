import { FilterLogicalOperator } from "models/Common/FilterLogicalOperator";
import { IFilterDetailsRequest } from "./IFilterDetailsRequest";

export interface IFilterRequest {
  logicalOperator: FilterLogicalOperator,
  Details: IFilterDetailsRequest[]
}