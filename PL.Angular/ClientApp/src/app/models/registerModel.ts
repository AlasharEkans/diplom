export class RegisterModel {

    constructor(
        public email: string = '',
        public password: string = '',
        public firstName: string = '',
        public lastName: string = ''
    ) {}

    isValid(): boolean {
        return !!this.email && !!this.password;
    }
}