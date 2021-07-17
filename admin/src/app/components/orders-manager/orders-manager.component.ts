import { HttpResponse } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Bill, BillCreateRequest, BillPaging } from '@app/models';
import { BillService } from '@app/shared/services';
import { TranslateService } from '@ngx-translate/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { Subject } from 'rxjs';
import { OrderManagerDetailsComponent } from './order-manager-details/order-manager-details.component';

@Component({
    selector: 'app-orders-manager',
    templateUrl: './orders-manager.component.html',
    styleUrls: ['./orders-manager.component.scss']
})
export class OrdersManagerComponent implements OnInit {

    constructor(private modalService: BsModalService,
        private toastr: ToastrService,
        private billService: BillService,
        private translate: TranslateService) {

    }
    twoFractionDigitNumberFormat: any;
    pageEvent: PageEvent;
    test: string;
    isLoadingResults: boolean;
    displayedColumns: string[] = ['no', 'customer-phone-number', 'total-price', 'discount-price', 'payment-amount', 'date', 'user-payment', 'edit'];
    dataSourceBillTable = new MatTableDataSource<Bill>();
    totalRow: number;
    pageIndex: number;
    pageSize: number;
    environment: any;
    txtSearch: string;
    public bsModalRef: BsModalRef;
    @ViewChild(MatPaginator) paginator: MatPaginator;
    eventsSubject: Subject<void> = new Subject<void>();

    ngOnInit(): void {
        this.pageEvent = {
            length: 0,
            pageIndex: 1,
            pageSize: 5,
            previousPageIndex: 0,
        }

        this.getDataPaging(this.pageEvent);
    }

    ngAfterViewInit() {
    }

    public getDataPaging(event: PageEvent) {
        this.billService.getPaging(event.pageIndex, event.pageSize, this.txtSearch).subscribe((res: HttpResponse<BillPaging>) => {
            if(res && res.status == 200){
                this.pageEvent.length = res.body.totalRow;
                this.dataSourceBillTable = new MatTableDataSource<Bill>(res.body.data)
            }
        })
    }

    public pageEventHandle(event?: PageEvent) {
        this.pageEvent = event;
        this.getDataPaging(this.pageEvent);

        return event;
    }

    public createdOrUpdated(entity: Bill = null) {

        const initialState = {
            entity: Object.assign({}, entity),
        };

        this.bsModalRef = this.modalService.show(OrderManagerDetailsComponent, {
            initialState: initialState,
            class: 'modal-full',
            backdrop: 'static'
        });

        this.bsModalRef.content.saved.subscribe((e) => {
            this.bsModalRef.hide();
            this.getDataPaging(this.pageEvent);
        });
    }

    deleted(element: Bill){
        console.log(element);
    }

    public onSearch() {
        console.log(this.txtSearch);
    }

}
