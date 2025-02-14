import type ExpenseDto from './ExpenseDto'

export default interface CategoryDto {
  id: number
  name: string
  metaDescription: string
  supCategoryId: number
  supCategoryName: string
  expenses: ExpenseDto[]
}
