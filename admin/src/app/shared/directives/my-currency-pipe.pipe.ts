import { Pipe, PipeTransform } from '@angular/core';


const PADDING = "000000";

@Pipe({ name: "myCurrency" })
export class MyCurrencyPipe implements PipeTransform {

  private DECIMAL_SEPARATOR: string;
//   private THOUSANDS_SEPARATOR: string;

  constructor() {
    // TODO comes from configuration settings
    this.DECIMAL_SEPARATOR = ".";
    //this.THOUSANDS_SEPARATOR = ".";
  }

  transform(value: number | string): string {

    let integer = value.toString().replace(/\B(?=(\d{3})+(?!\d))/g, this.DECIMAL_SEPARATOR);

    return integer ;
  }

  parse(value: string): string {

    let integer = value.replace(/\./g, "");

    return integer ;
  }
}