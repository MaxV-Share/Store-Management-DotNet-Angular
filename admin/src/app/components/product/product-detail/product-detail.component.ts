import { Component, EventEmitter, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import CategoryDetailComponent from '@app/components/category/category-detail/category-detail.component';
import { TranslateService } from '@ngx-translate/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Observable, of, Subscription } from 'rxjs';
import { debounceTime, delay, finalize, map, startWith, switchMap, tap } from 'rxjs/operators';
import { Lang, Category, Product, ProductDetail, ENVIRONMENT, langs, CategoryDetail } from '@app/models';
import { CategoryService, UtilitiesService } from '@app/shared/services';
import { ProductService } from '@app/shared/services/product.service';
import { ToastrService } from 'ngx-toastr';

@Component({
    selector: 'app-product-detail',
    templateUrl: './product-detail.component.html',
    styleUrls: ['./product-detail.component.scss']
})
export class ProductDetailComponent implements OnInit {

    constructor(private modalService: BsModalService,
        private categoryService: CategoryService,
        private productService: ProductService,
        private utilitiesService: UtilitiesService,
        public bsModalRef: BsModalRef,
        public bsCategoryModalRef: BsModalRef,
        private toastr: ToastrService,
        public translate: TranslateService) {

    }
    showAddCategory = false;
    showEditCategory = false;
    langs: Lang[];
    public productId: number;
    saved: EventEmitter<any> = new EventEmitter();
    entity: Product = new Product();
    ctrCategory = new FormControl();
    options: string[] = ['One', 'Two', 'Three'];
    filteredOptions: Observable<CategoryDetail[]>;
    categories: CategoryDetail[];
    uploadedFiles: any[] = [];
    isLoadingAutocompleteCategory: boolean;
    private subscription = new Subscription();
    test: any;
    getEntity() {
        this.entity = {
            id: null,
            urlImage: "",
            details: [
            ]
        };
        this.langs.forEach(e => {
            this.entity.details.push({
                langId: e.id,
                name: "",
                description: "",
                product: null,
                productId: null
            })
        })

        // this.categories = [
        //     { categoryId: 1, name: "Danh mục 1", description: "11", category: { id: 1, parentId: null }, langId: "vi" },
        //     { categoryId: 2, name: "Danh mục 2", description: "22", category: { id: 2, parentId: null }, langId: "vi" },
        // ];

    }

    ngOnInit(): void {
        this.langs = langs;
        this.getEntity();
        this.getCategory();

        this.ctrCategory.valueChanges
            .pipe(
                debounceTime(500),
                tap(() => {
                    //   this.errorMsg = "";
                    //   this.filteredMovies = [];
                    this.isLoadingAutocompleteCategory = true;
                }), switchMap(searchValue => {
                    this.isLoadingAutocompleteCategory = true;
                    return this.categoryService.getAll(searchValue).pipe(
                        delay(100),
                        finalize(() => {
                            this.isLoadingAutocompleteCategory = false
                        }))
                })
            )
            .subscribe((data: CategoryDetail[]) => {
                this.isLoadingAutocompleteCategory = true;
                this.categories = data;
                this.filteredOptions = of(data);
            });
    }

    onSave() {
        // this.saved.emit("Saved");
        this.entity.categoryId = this.ctrCategory.value.categoryId;
        //console.log(this.ctrCategory.value);

        const formData = this.utilitiesService.ToFormData(this.entity);
        if (this.uploadedFiles.length > 0) {
            formData.append('file', this.uploadedFiles[0], this.uploadedFiles[0].name);
        }
        this.productService.add(formData).subscribe(() => {
            this.toastr.success('Success');
            this.saved.emit("success");
            console.log("success");
            // setTimeout(() => { this.blockedPanel = false; this.btnDisabled = false; }, 1000);
        }, err => {
            // this.notificationService.showError(MessageConstants.DEFAULT_ERROR_MSG);
            // console.log(error);
            // setTimeout(() => { this.blockedPanel = false; this.btnDisabled = false; }, 1000);
            console.error(err)
        });
    }

    changeTab(index: number) {
        // console.log(this.langs[index].id);
        // this.translate.use(this.langs[index].id);
    }

    displayFn(user: CategoryDetail): string {
        return user && user.name ? user.name : '';
    }

    dealWithFiles(event) {
        this.uploadedFiles = event.currentFiles;
    }

    createCategory() {
        const initialState = {
            id: null,
        };

        this.bsCategoryModalRef = this.modalService.show(CategoryDetailComponent, {
            initialState: initialState,
            class: 'modal-lg',
            backdrop: 'static'
        });

        this.bsCategoryModalRef.content.saved.subscribe((e) => {
            this.bsCategoryModalRef.hide();
            this.getCategory();
        });
    }
    submitForm() {

    }

    editCategory(categoryId) {
        const initialState = {
            id: categoryId,
        };

        this.bsCategoryModalRef = this.modalService.show(CategoryDetailComponent, {
            initialState: initialState,
            class: 'modal-lg',
            backdrop: 'static',
            focus: false
        });

        this.bsCategoryModalRef.content.saved.subscribe((e) => {
            this.bsCategoryModalRef.hide();
            this.getCategory();
        });
    }
    getCategory() {
        this.categoryService.getAll().subscribe((res: CategoryDetail[]) => {
            this.categories = res;
            this.filteredOptions = this.ctrCategory.valueChanges
                .pipe(
                    startWith(''),
                    map(value => typeof value === 'string' ? value : value.name),
                    map(name => this.categories.slice())
                );
        })
    }
}
