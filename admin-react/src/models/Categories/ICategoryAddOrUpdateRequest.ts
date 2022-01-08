import { ICategoryDetailAddOrUpdateRequest } from "models/CategoryDetails";

export interface ICategoryAddOrUpdateRequest {
  details: ICategoryDetailAddOrUpdateRequest[],
  parentId: number
}
