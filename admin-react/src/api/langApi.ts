import { IBasePaging, IFilterBodyRequest, ILangViewModel } from '../models';
import axiosClient from './axiosClient';

const langApi = {
  getAll(data: IFilterBodyRequest): Promise<IBasePaging<ILangViewModel>> {
    const url = '/langs/filter';
    return axiosClient.post(url, data);
  },
};

export default langApi;
