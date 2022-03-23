import { IBaseViewModel } from "models";

export interface ICategoryDetailAddOrUpdateRequest extends IBaseViewModel<number> {
  categoryId?: number,
  langId: string,
  name: string,
  description: string,
}
