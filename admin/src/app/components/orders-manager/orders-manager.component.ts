import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Bill, BillCreateRequest } from '@app/models';
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
    displayedColumns: string[] = ['no', 'customer-phone-number', 'total-price', 'discount-price', 'user-payment','edit'];
    dataSourceBillTable = new MatTableDataSource<Bill>();
    totalRow: number;
    pageIndex: number;
    pageSize: number;
    environment: any;
    txtSearch: string;
    itemModal: Bill | BillCreateRequest
    public bsModalRef: BsModalRef;
    @ViewChild(MatPaginator) paginator: MatPaginator;
    eventsSubject: Subject<void> = new Subject<void>();

    ngOnInit(): void {
        this.twoFractionDigitNumberFormat = new Intl.NumberFormat('vi-VN')
        this.pageEvent = {
            length: 0,
            pageIndex: 0,
            pageSize: 5,
            previousPageIndex: 0,
        }

        this.getDataPaging(this.pageEvent);
    }

    ngAfterViewInit() {
    }

    public getDataPaging(event: PageEvent) {
        this.billService.getAll().subscribe((res : Bill[]) => {
            console.log(res);
            this.dataSourceBillTable = new MatTableDataSource<Bill>(res)
        })
    }

    public pageEventHandle(event?: PageEvent) {
        console.log(event);
        this.getDataPaging(event);

        return event;
    }

    public createOrUpdate(entity: Bill = null) {
        this.itemModal = entity;
        const initialState = {
            entity: entity,
        };

        this.bsModalRef = this.modalService.show(OrderManagerDetailsComponent, {
            initialState: initialState,
            class: 'modal-full',
            backdrop: 'static'
        });

        this.bsModalRef.content.saved.subscribe((e) => {
            this.bsModalRef.hide();
        });
    }
    public onSearch() {
        console.log(this.txtSearch);

    }

}
