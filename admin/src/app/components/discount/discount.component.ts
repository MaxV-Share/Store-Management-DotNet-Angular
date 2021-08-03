import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { Discount } from '@app/models';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { merge } from 'rxjs/internal/observable/merge';
import { startWith } from 'rxjs/internal/operators/startWith';
import { catchError, map, switchMap } from 'rxjs/operators';
import { of as observableOf } from 'rxjs/internal/observable/of';
import { Subject } from 'rxjs/internal/Subject';
import { DiscountDetailComponent } from './discount-detail/discount-detail.component';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { TranslateService } from '@ngx-translate/core';

@Component({
    selector: 'app-discount',
    templateUrl: './discount.component.html',
    styleUrls: ['./discount.component.scss']
})
export class DiscountComponent implements OnInit, AfterViewInit {

    constructor(private modalService: BsModalService, private toastr: ToastrService, private translate: TranslateService) { }
    twoFractionDigitNumberFormat: any;
    pageEvent: PageEvent;
    test: string;
    isLoadingResults: boolean;
    displayedColumns: string[] = ['no', 'name', 'weight', 'edit'];
    dataSource = new MatTableDataSource<Discount>();
    itemModal: Discount;
    txtSearch: string;
    public bsModalRef: BsModalRef;
    @ViewChild(MatPaginator) paginator: MatPaginator;
    eventsSubject: Subject<void> = new Subject<void>();

    ngOnInit(): void {
        this.twoFractionDigitNumberFormat = new Intl.NumberFormat('vi-VN')
        this.pageEvent = {
            length: ELEMENT_DATA.length,
            pageIndex: 0,
            pageSize: 5,
            previousPageIndex: 0,
        }

        this.getDataPaging(this.pageEvent);
    }

    ngAfterViewInit() {
    }
    public getDataPaging(event: PageEvent) {
        var data: Discount[] = [];
        let indexTo = event.pageIndex * event.pageSize + event.pageSize;
        let indexFrom = event.pageIndex * event.pageSize;
        for (let i = 0; i < ELEMENT_DATA.length; i++) {
            if (i < indexFrom)
                continue;
            if (i >= indexTo)
                break;
            data.push(ELEMENT_DATA[i]);
        }
        this.dataSource = new MatTableDataSource<Discount>(data);
    }

    public pageEventHandle(event: PageEvent) {
        console.log(event);
        this.getDataPaging(event);

        return event;
    }

    public edit(entity: Discount) {
        this.itemModal = entity;
        const initialState = {
            entity: this.itemModal,
        };

        this.bsModalRef = this.modalService.show(DiscountDetailComponent, {
            initialState: initialState,
            class: 'modal-lg',
            backdrop: 'static'
        });

        this.bsModalRef.content.saved.subscribe((e) => {
            console.log(e);
            this.bsModalRef.hide();
        });
    }
    public onSearch(){
        console.log(this.txtSearch);

    }
}

export interface PeriodicElement {
    name: string;
    position: number;
    weight: number;
    symbol: string;
}

const ELEMENT_DATA: Discount[] = [
    { id: 1,  percentDiscount: 11, maxDiscountPrice: 11000, fromDate: null, toDate: null },
    { id: 2,  percentDiscount: 12, maxDiscountPrice: 12000, fromDate: null, toDate: null },
    { id: 3,  percentDiscount: 13, maxDiscountPrice: 13000, fromDate: null, toDate: null },
    { id: 4,  percentDiscount: 14, maxDiscountPrice: 14000, fromDate: null, toDate: null },
    { id: 5,  percentDiscount: 15, maxDiscountPrice: 15000, fromDate: null, toDate: null },
    { id: 6,  percentDiscount: 16, maxDiscountPrice: 16007, fromDate: null, toDate: null },
    { id: 7,  percentDiscount: 17, maxDiscountPrice: 17007, fromDate: null, toDate: null },
    { id: 8,  percentDiscount: 18, maxDiscountPrice: 18004, fromDate: null, toDate: null },
    { id: 9,  percentDiscount: 19, maxDiscountPrice: 19004, fromDate: null, toDate: null },
    { id: 10, percentDiscount: 20, maxDiscountPrice: 20007, fromDate: null, toDate: null },
    { id: 11, percentDiscount: 21, maxDiscountPrice: 21007, fromDate: null, toDate: null },
    { id: 12, percentDiscount: 22, maxDiscountPrice: 22000, fromDate: null, toDate: null },
    { id: 13, percentDiscount: 23, maxDiscountPrice: 23005, fromDate: null, toDate: null },
    { id: 14, percentDiscount: 24, maxDiscountPrice: 24005, fromDate: null, toDate: null },
    { id: 15, percentDiscount: 25, maxDiscountPrice: 25008, fromDate: null, toDate: null },
    { id: 16, percentDiscount: 26, maxDiscountPrice: 26000, fromDate: null, toDate: null },
    { id: 17, percentDiscount: 27, maxDiscountPrice: 27000, fromDate: null, toDate: null },
    { id: 18, percentDiscount: 28, maxDiscountPrice: 28000, fromDate: null, toDate: null },
    { id: 19, percentDiscount: 29, maxDiscountPrice: 29003, fromDate: null, toDate: null },
    { id: 20, percentDiscount: 30, maxDiscountPrice: 30000, fromDate: null, toDate: null },
];
