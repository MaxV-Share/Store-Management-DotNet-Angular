import { Directive, HostListener, ElementRef, OnInit } from "@angular/core";
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';
import { MAT_INPUT_VALUE_ACCESSOR } from '@angular/material/input';
import { Subscription } from 'rxjs';
import { formatNumber } from '@angular/common';
import { Pipe, PipeTransform } from "@angular/core";
import { MyCurrencyPipe } from "./my-currency-pipe.pipe";


@Directive({
    selector: '[localizedNumericInput]'
})
export default class LocalizedNumericInputDirective {

    private el: HTMLInputElement;

    constructor(
      private elementRef: ElementRef,
      private currencyPipe: MyCurrencyPipe
    ) {
      this.el = this.elementRef.nativeElement;
    }
  
    ngOnInit() {
      this.el.value = this.currencyPipe.transform(this.el.value);
    } 
    
    @HostListener('input', ['$event.target.value'])
    input(value:string ) {  
      // here to notify Angular Validators
      this.el.value = this.currencyPipe.transform(this.el.value);
    }
  
    @HostListener("focus", ["$event.target.value"])
    onFocus(value : string) {
      this.el.value = this.currencyPipe.parse(value); // opossite of transform
    }
  
    @HostListener("blur", ["$event.target.value"])
    onBlur(value : string | number) {
      this.el.value = this.currencyPipe.transform(value);
    }
}

