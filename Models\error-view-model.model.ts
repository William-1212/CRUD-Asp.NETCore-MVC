import { AbstractValidator } from 'fluent-ts-validator';

export class ErrorViewModel {
  public requestId: string = '';

  constructor(init?: Partial<ErrorViewModel>) {
    Object.assign(this, init);
  }
}

export class ErrorViewModelValidator extends AbstractValidator<ErrorViewModel>{
  constructor() {
    super();

}
