import { IBaseViewModel } from "models";

export interface ICategoryDetailViewModel extends IBaseViewModel<number> {
  categoryId: number,
  langId: string,
  name: string,
  description: string,
}