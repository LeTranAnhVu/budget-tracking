export default interface CategoryDto {
  id: number
  name: string
  metaDescription: string
  supCategoryId: number
  supCategoryName: string
  expenses: never // TODO this one should be removed
}
