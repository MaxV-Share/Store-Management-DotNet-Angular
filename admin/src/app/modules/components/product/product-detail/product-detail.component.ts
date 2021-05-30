import { Component, EventEmitter, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { TranslateService } from '@ngx-translate/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';
import { Lang, Category, Product, ProductDetail, environment, langs, CategoryDetail } from '../../../../models';

@Component({
    selector: 'app-product-detail',
    templateUrl: './product-detail.component.html',
    styleUrls: ['./product-detail.component.scss']
})
export class ProductDetailComponent implements OnInit {

    constructor(private modalService: NgbModal, public bsModalRef: BsModalRef, private translate: TranslateService) {

    }
    langs: Lang[];
    public productId: number;
    saved: EventEmitter<any> = new EventEmitter();
    entity: Product;
    myControl = new FormControl();
    options: string[] = ['One', 'Two', 'Three'];
    filteredOptions: Observable<CategoryDetail[]>;
    categories: CategoryDetail[];
    uploadedFiles: any[] = [];
    getEntity() {
        this.entity = {
            categoryId: 1,
            id: 1,
            price: 100000,
            urlImage: "",
            details: [{
                langId: "vi",
                name: "Sản phẩm 1",
                description: "Mô tả về sản phẩm: Lorem Ipsum chỉ đơn giản là một đoạn văn bản giả, ",
                product: null,
                productId: 1
            },{
                langId: "en",
                name: "Product 1",
                description: "Product description: Lorem ipsum dolor sit amet, consectetur adipiscing elit,",
                product: null,
                productId: 1
            }
            ]
        };

        this.categories = [
            { categoryId: 1, name: "Danh mục 1", description: "11", category: { id: 1, parentId: null }, langId: "vi" },
            { categoryId: 2, name: "Danh mục 2", description: "22", category: { id: 2, parentId: null }, langId: "vi" },
        ];

        this.filteredOptions = this.myControl.valueChanges
            .pipe(
                startWith(''),
                map(value => typeof value === 'string' ? value : value.name),
                map(name => name ? this._filter(name) : this.categories.slice())
            );

    }
    ngOnInit(): void {
        console.log(this.productId);
        this.langs = langs;
        this.getEntity();
    }

    onSave() {
        // this.saved.emit("Saved");
        //console.log(this.entity);

        this.log(typeof this.myControl.value)
    }
    changeTab(index: number) {
        // console.log(this.langs[index].id);
        // this.translate.use(this.langs[index].id);
    }
    log(item: any) {
        console.log(item)
    }
    displayFn(user: CategoryDetail): string {
        return user && user.name ? user.name : '';
    }

    private _filter(name: string): CategoryDetail[] {
        const filterValue = name.toLowerCase();
        return this.categories.filter(option => option.name.toLowerCase().indexOf(filterValue) >= 0);
    }
    onUpload(event) {
        for (let file of event.files) {
            this.uploadedFiles.push(file);
        }

        //this.messageService.add({severity: 'info', summary: 'File Uploaded', detail: ''});
    }
}
