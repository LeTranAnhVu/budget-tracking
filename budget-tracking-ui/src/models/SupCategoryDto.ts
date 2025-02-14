import type CategoryDto from './CategoryDto'

export default interface SupCategoryDto {
  id: number
  name: string
  metaDescription: string
  categories: CategoryDto[]
}
