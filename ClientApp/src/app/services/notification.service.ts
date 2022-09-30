import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { C } from '../../constants/C';
import { Student } from 'src/interfaces/catalog/student';
import { dataBody } from 'src/interfaces/catalog/dataBody';
import { NotificationMsg } from 'src/interfaces/internal/notification';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {
  private notificator : BehaviorSubject<NotificationMsg> | null = null;

  constructor() {
  }

  public emitNotification(notification: NotificationMsg) {
    if(!this.isValid()) {
      this.notificator = new BehaviorSubject<NotificationMsg>(notification);
    } else {
      this.notificator?.next(notification)
    }
  }

  public subscribeNotification(callback: (n: NotificationMsg) => void) {
    this.notificator?.subscribe(callback);
  }

  private isValid() : boolean {
    return this.notificator != null;
  }
}
