import {CostumerItemService} from './../../shared/costumer-item.service';
import {Component, OnInit} from '@angular/core';
import {NgForm} from '@angular/forms';
import {ToastrService} from 'ngx-toastr';

@Component({
  selector: 'app-costumer-item',
  templateUrl: './costumer-item.component.html',
  styles: [],
})

export class CostumerItemComponent implements OnInit {

  constructor(public service: CostumerItemService, public toastr: ToastrService) {
  }

  ngOnInit() {
    this.resetForm();
  }

  resetForm(form?: NgForm) {
    if (form != null) {
      form.form.reset();
    }
    this.service.formData = {
      id: 0,
      name: '',
      document: '',
      carModel: '',
      carYear: 0,
      carPlate: '',
    };
  }

  onSubmit(form: NgForm) {
    if (this.service.formData.id === 0) {
      this.insertRecord(form);
    } else {
      this.updateRecord(form);
    }
  }

  insertRecord(form: NgForm) {
    this.service.postPaymentDetail().subscribe(
      res => {
        this.resetForm(form);
        this.toastr.success('Submitted successfully', 'Costumer Registration');
        this.service.refreshList();
      },
      err => {
        console.log(err);
      },
    );
  }

  updateRecord(form: NgForm) {
    this.service.putPaymentDetail().subscribe(
      res => {
        this.resetForm(form);
        this.toastr.info('Submitted successfully', 'Costumer Registration');
        this.service.refreshList();
      },
      err => {
        console.log(err);
      },
    );
  }

}
