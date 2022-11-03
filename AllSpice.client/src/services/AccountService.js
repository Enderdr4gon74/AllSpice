import { AppState } from '../AppState'
import { Account } from '../models/Account.js'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'
import { favoritesService } from './FavoritesService.js'

class AccountService {
  async getAccount() {
    try {
      const res = await api.get('/account')
      AppState.account = res.data
      favoritesService.getFavorites()
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }

  async editAccount(accountData) {
    console.log(accountData.name)
    const newAccount = await api.put("/account", accountData)
    AppState.account = new Account(newAccount.data)
  }
}

export const accountService = new AccountService()
