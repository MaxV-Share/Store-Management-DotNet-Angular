import { BaseViewModel } from '../Bases';
export interface ICategoryViewModel extends BaseViewModel<number> {
  categoryId: number,
  langId: string,
  name: string,
  description: string,
}