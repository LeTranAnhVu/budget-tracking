export default interface ExpenseDto {
  id: number
  amount: number
  categoryId: number
  createdAt: string
  createdBy: number
  updatedAt: string
  updatedBy: number
  paidDate: string
  includedTax: boolean
  note: string
  vat: number | null
}
