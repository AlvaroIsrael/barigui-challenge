import {CostumerItem} from './costumer-item.model';
import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class CostumerItemService {
  formData: CostumerItem;
  readonly rootURL = 'https://localhost:5001/api';
  list: CostumerItem[];

  constructor(private http: HttpClient) {
  }

  postPaymentDetail() {
    // tslint:disable-next-line:radix
    this.formData.carYear = parseInt(String(this.formData.carYear));
    return this.http.post(this.rootURL + '/CostumerItems', this.formData);
  }

  putPaymentDetail() {
    return this.http.put(this.rootURL + '/CostumerItems/' + this.formData.id, this.formData);
  }

  deletePaymentDetail(id) {
    return this.http.delete(this.rootURL + '/CostumerItems/' + id);
  }

  refreshList() {
    this.http.get(this.rootURL + '/CostumerItems')
      .toPromise()
      .then(res => this.list = res as CostumerItem[]);
  }
}
