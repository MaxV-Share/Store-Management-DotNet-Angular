export enum ComponentsEnum {
  Dashboard = 'Dashboard',
  ProductCategory = 'ProductCategory',
  Category = 'Category',
  Function = 'Function',
}
const StringIsNumber = (value: any) => {
  console.log("StringIsNumber", value, isNaN(Number(value)));

  return isNaN(Number(value)) === false;
}
const ToArray = (enumType: any) => Object.keys(enumType).map(key => enumType[key]);

export const Components: string[] = ToArray(ComponentsEnum);