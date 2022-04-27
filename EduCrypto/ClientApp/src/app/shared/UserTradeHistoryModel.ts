import { UserHandlingModel } from "./UserHandlingModel";

export class UserTradeHistoryModel
{
    public userHandlingModel : UserHandlingModel;
    public userHandlingModelId: number;
    public boughtValue: number;
    public spentCryptoSymbol: string;
    public tradeDate: Date;
    public spentValue: string;
    public userForGroupsModelId?: number;
}