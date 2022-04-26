import { UserHandlingModel } from "src/app/shared/user-handling.model";


export class UserCryptoModel
{
    public UserHandlingModel : UserHandlingModel;
    public userHandlingModelId: number;
    public CryptoSymbol: string;
    public CryptoValue: number;
    public isFavourite: boolean;
}