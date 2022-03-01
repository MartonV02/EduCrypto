import { BackendUrlEnum } from "./BackendUrlEnum.constant";

export class GenericUrlGenerator
{
  private _UriPrefix = "api/";
  private _backendUrlEnum: BackendUrlEnum;
  
  constructor(backendUrlEnum: BackendUrlEnum)
  {
    this._backendUrlEnum = backendUrlEnum;
  }

  GetBasicUrl(): string
  {
    var HttpUri = this._UriPrefix + this._backendUrlEnum;

    return HttpUri;
  }

  GetUrlWithParam(id?: number, action?: string): string
  {


    var HttpUri = this._UriPrefix + this._backendUrlEnum;

    
    if (action)
    {
      HttpUri += "/"+ action;
    }
    if (id)
    {
      HttpUri +="/"+ id;
    }
    
    return HttpUri;
  }
}
