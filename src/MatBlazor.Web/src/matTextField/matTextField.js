import './matTextField.scss';
import {MDCTextField} from '@material/textfield';

export class MatTextField {
  constructor(ref) {
    this.textField = new MDCTextField(ref);
  }
}

export function init(ref) {
  ref.__matBlazor_component = new MatTextField(ref);
}


export function getValid(ref) {
  return ref.__matBlazor_component.textField.valid;
}


export function setValid(ref, value) {
  ref.__matBlazor_component.textField.valid = value;
}
