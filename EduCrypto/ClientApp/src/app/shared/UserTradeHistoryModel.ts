import { UserHandlingModel } from "./UserHandlingModel";

export class UserTradeHistoryModel
{
    public UserHandlingModel : UserHandlingModel;
    public userHandlingModelId: number;
    public spentCryptoSymbol: string;
    public spentValue: string;
    public userForGroupsModelId?: number;
}