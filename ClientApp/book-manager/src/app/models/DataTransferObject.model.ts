export interface DataTransferObject<T> {
  data: T;
  header: HttpHeader;
}

export interface HttpHeader {
  code: number;
  message: string;
}
