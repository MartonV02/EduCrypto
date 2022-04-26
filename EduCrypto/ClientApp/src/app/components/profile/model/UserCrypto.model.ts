import { UserHandlingModel } from "src/app/shared/UserHandlingModel";


export class UserCryptoModel
{
    public UserHandlingModel : UserHandlingModel;
    public userHandlingModelId: number;
    public cryptoSymbol: string;
    public cryptoValue: number;
    public isFavourite: boolean;
}