import { ICategoryDetailAddOrUpdateRequest } from "models/CategoryDetails";

export interface ICategoryAddOrUpdateRequest {
  isLoading?: boolean,
  id?: number,
  details: ICategoryDetailAddOrUpdateRequest[],
  parentId?: number
}
