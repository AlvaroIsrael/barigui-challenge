import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';

import {FormsModule} from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';

import {ToastrModule} from 'ngx-toastr';
import {AppComponent} from './app.component';
import {CostumerItemsComponent} from './costumer-items/costumer-items.component';
import {CostumerItemComponent} from './costumer-items/costumer-item/costumer-item.component';
import {CostumerItemListComponent} from './costumer-items/costumer-item-list/costumer-item-list.component';
import {CostumerItemService} from './shared/costumer-item.service';
import {NzTableModule} from 'ng-zorro-antd';

@NgModule({
  declarations: [
    AppComponent,
    CostumerItemsComponent,
    CostumerItemComponent,
    CostumerItemListComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    NzTableModule,
  ],
  providers: [CostumerItemService],
  bootstrap: [AppComponent],
})
export class AppModule {
}
