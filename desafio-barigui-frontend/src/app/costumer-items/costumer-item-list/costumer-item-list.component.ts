import {CostumerItem} from './../../shared/costumer-item.model';
import {CostumerItemService} from './../../shared/costumer-item.service';
import {Component, OnInit} from '@angular/core';
import {ToastrService} from 'ngx-toastr';

@Component({
  selector: 'app-costumer-item-list',
  templateUrl: './costumer-item-list.component.html',
  styles: [],
})
export class CostumerItemListComponent implements OnInit {

  constructor(public service: CostumerItemService,
              public toastr: ToastrService) {
  }

  ngOnInit() {
    this.service.refreshList();
  }

  populateForm(pd: CostumerItem) {
    this.service.formData = Object.assign({}, pd);
  }

  onDelete(id) {
    if (confirm('Are you sure to delete this record ?')) {
      this.service.deletePaymentDetail(id)
        .subscribe(res => {
            /*debugger;*/
            this.service.refreshList();
            this.toastr.warning('Deleted successfully', 'Costumer Registration');
          },
          err => {
            /*debugger;*/
            console.log(err);
          });
    }
  }

}
